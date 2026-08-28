import type { TapListDto, TapRequest, TapResult } from '../types/tap';

// Dev: порожньо — Vite проксіює /taps і /rooms/*/taps на бек (див. vite.config.ts).
// Prod: повний origin піддомену API (VITE_API_BASE_URL).
const BASE: string = import.meta.env.VITE_API_BASE_URL ?? '';

// POST /taps — і успіх (200), і відмова (404/409) повертають тіло TapResult.
export async function postTap(request: TapRequest): Promise<TapResult> {
  const res = await fetch(`${BASE}/taps`, {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(request),
  });

  const contentType = res.headers.get('content-type') ?? '';
  if (!contentType.includes('application/json')) {
    throw new Error(`Несподівана відповідь сервера (${res.status})`);
  }

  return (await res.json()) as TapResult;
}

// GET /rooms/{code}/taps — 404 означає, що кімнати немає (не те саме, що порожній список).
export async function getRoomTaps(code: string): Promise<TapListDto | null> {
  const res = await fetch(`${BASE}/rooms/${encodeURIComponent(code)}/taps`);

  if (res.status === 404) return null;
  if (!res.ok) throw new Error(`Помилка завантаження (${res.status})`);

  return (await res.json()) as TapListDto;
}
