import react from '@vitejs/plugin-react';
import { defineConfig } from 'vite';

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    // Dev-проксі на бек, щоб уникнути CORS. У проді фронт і бек — на різних
    // піддоменах, тож там знадобиться CORS на беку + VITE_API_BASE_URL.
    // Ключ із ^ — це RegExp: проксіюємо лише API-шлях /rooms/{code}/taps,
    // а SPA-маршрут /rooms/{code} лишаємо фронту.
    proxy: {
      '/taps': { target: 'http://localhost:5280', changeOrigin: true },
      '^/rooms/[^/]+/taps$': { target: 'http://localhost:5280', changeOrigin: true },
    },
  },
});
