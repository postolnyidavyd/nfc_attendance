import { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getRoomTaps } from '../api/client';
import type { TapDto } from '../types/tap';
import { Banner, Card, Eyebrow, Muted, RoomCode, TapsTable, TextLink } from '../styles/ui';

type State =
  | { kind: 'loading' }
  | { kind: 'not-found' }
  | { kind: 'error'; message: string }
  | { kind: 'loaded'; taps: TapDto[] };

export default function RoomTapsPage() {
  const { code } = useParams<{ code: string }>();
  const [state, setState] = useState<State>({ kind: 'loading' });

  useEffect(() => {
    if (!code) return;
    let cancelled = false;

    setState({ kind: 'loading' });
    getRoomTaps(code)
      .then((data) => {
        if (cancelled) return;
        setState(data === null ? { kind: 'not-found' } : { kind: 'loaded', taps: data.taps });
      })
      .catch((e) => {
        if (cancelled) return;
        setState({ kind: 'error', message: e instanceof Error ? e.message : 'Невідома помилка' });
      });

    return () => {
      cancelled = true;
    };
  }, [code]);

  return (
    <Card>
      <Eyebrow>Відмітки аудиторії</Eyebrow>
      <RoomCode>{code}</RoomCode>

      {state.kind === 'loading' && <Muted>Завантаження…</Muted>}
      {state.kind === 'not-found' && <Banner $variant="error">Такої аудиторії не існує</Banner>}
      {state.kind === 'error' && <Banner $variant="error">{state.message}</Banner>}

      {state.kind === 'loaded' &&
        (state.taps.length === 0 ? (
          <Muted>Ще ніхто не відмічався.</Muted>
        ) : (
          <TapsTable>
            <thead>
              <tr>
                <th>Студент</th>
                <th>Група</th>
                <th>Час</th>
              </tr>
            </thead>
            <tbody>
              {state.taps.map((t) => (
                <tr key={t.id}>
                  <td>{t.fullName}</td>
                  <td>{t.groupName}</td>
                  <td>{new Date(t.createdAt).toLocaleString('uk-UA')}</td>
                </tr>
              ))}
            </tbody>
          </TapsTable>
        ))}

      <TextLink to={`/t/${code}`}>← До сторінки відмітки</TextLink>
    </Card>
  );
}
