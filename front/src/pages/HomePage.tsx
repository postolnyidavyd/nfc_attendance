import { Card, Code, Eyebrow, Muted, RoomBadge, RoomList, TextLink, Title } from '../styles/ui';

// Допоміжна сторінка для розробки/демо: мітка в реальності одразу веде на /t/{code}.
const rooms = ['201', '303', '105', '402'];

export default function HomePage() {
  return (
    <Card>
      <Eyebrow>NFC Присутність</Eyebrow>
      <Title>Аудиторії</Title>
      <Muted>
        У продакшені студент потрапляє на <Code>/t/&#123;код&#125;</Code> через NFC-мітку. Тут — ручні
        посилання для перевірки.
      </Muted>

      <RoomList>
        {rooms.map((code) => (
          <li key={code}>
            <RoomBadge>{code}</RoomBadge>
            <TextLink to={`/t/${code}`}>відмітитись</TextLink>
            <TextLink to={`/rooms/${code}`}>відмітки</TextLink>
          </li>
        ))}
      </RoomList>
    </Card>
  );
}
