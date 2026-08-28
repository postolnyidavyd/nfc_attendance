import { useState } from 'react';
import { useParams } from 'react-router-dom';
import { postTap } from '../api/client';
import { seedStudents } from '../data/students';
import type { TapResult } from '../types/tap';
import {
  Banner,
  Card,
  Eyebrow,
  Field,
  PrimaryButton,
  RoomCode,
  Select,
  TextLink,
} from '../styles/ui';

type Status =
  | { kind: 'idle' }
  | { kind: 'submitting' }
  | { kind: 'done'; result: TapResult }
  | { kind: 'error'; message: string };

export default function TapPage() {
  const { code } = useParams<{ code: string }>();
  const [userId, setUserId] = useState(seedStudents[0].id);
  const [status, setStatus] = useState<Status>({ kind: 'idle' });

  async function confirm() {
    if (!code) return;
    setStatus({ kind: 'submitting' });
    try {
      const result = await postTap({ roomCode: code, userId });
      setStatus({ kind: 'done', result });
    } catch (e) {
      setStatus({ kind: 'error', message: e instanceof Error ? e.message : 'Невідома помилка' });
    }
  }

  return (
    <Card>
      <Eyebrow>Аудиторія</Eyebrow>
      <RoomCode>{code}</RoomCode>

      {/* ФАЗА 1: вибір студента вручну. У фазі 2 — passkey замість списку. */}
      <Field>
        <span>Хто відмічається</span>
        <Select
          value={userId}
          onChange={(e) => setUserId(e.target.value)}
          disabled={status.kind === 'submitting'}
        >
          {seedStudents.map((s) => (
            <option key={s.id} value={s.id}>
              {s.fullName} ({s.groupName})
            </option>
          ))}
        </Select>
      </Field>

      {/* Кнопка, а не автовиклик: у фазі 2 Safari вимагає жест користувача для passkey. */}
      <PrimaryButton onClick={confirm} disabled={status.kind === 'submitting'}>
        {status.kind === 'submitting' ? 'Відмічаємо…' : 'Підтвердити присутність'}
      </PrimaryButton>

      {status.kind === 'done' && <ResultBanner result={status.result} />}
      {status.kind === 'error' && <Banner $variant="error">{status.message}</Banner>}

      <TextLink to={`/rooms/${code}`}>Переглянути відмітки цієї аудиторії →</TextLink>
    </Card>
  );
}

function ResultBanner({ result }: { result: TapResult }) {
  if (result.success) {
    return <Banner $variant="success">✓ Присутність зараховано</Banner>;
  }
  // AlreadyTapped — це радше інформація, ніж помилка; решта причин — помилки.
  const variant = result.reason === 'AlreadyTapped' ? 'info' : 'error';
  return <Banner $variant={variant}>{result.message ?? 'Не вдалося відмітитись'}</Banner>;
}
