import { Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import RoomTapsPage from './pages/RoomTapsPage';
import TapPage from './pages/TapPage';

export default function App() {
  return (
    <Routes>
      <Route path="/" element={<HomePage />} />
      <Route path="/t/:code" element={<TapPage />} />
      <Route path="/rooms/:code" element={<RoomTapsPage />} />
    </Routes>
  );
}
