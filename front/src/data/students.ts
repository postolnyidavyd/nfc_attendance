// ФАЗА 1: автентифікації ще немає, тож userId треба звідкись узяти.
// Це тимчасова заглушка — ті самі студенти, що засіяні в БД (UserConfiguration.HasData).
// У фазі 2 її замінить WebAuthn/passkey: користувача визначатиме ключ, а не вибір зі списку.

export interface SeedStudent {
  id: string;
  fullName: string;
  groupName: string;
}

export const seedStudents: SeedStudent[] = [
  { id: '22222222-2222-2222-2222-000000000001', fullName: 'Іван Петренко', groupName: 'КН-21' },
  { id: '22222222-2222-2222-2222-000000000002', fullName: 'Марія Коваленко', groupName: 'КН-21' },
  { id: '22222222-2222-2222-2222-000000000003', fullName: 'Олег Шевчук', groupName: 'ІПЗ-22' },
  { id: '22222222-2222-2222-2222-000000000004', fullName: 'Софія Бондаренко', groupName: 'ІПЗ-22' },
  { id: '22222222-2222-2222-2222-000000000005', fullName: 'Андрій Мельник', groupName: 'КБ-23' },
  { id: '22222222-2222-2222-2222-000000000006', fullName: 'Наталія Ткаченко', groupName: 'КБ-23' },
];
