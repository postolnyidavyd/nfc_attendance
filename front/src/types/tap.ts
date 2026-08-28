// Дзеркало контрактів беку (DTOs.Tap). Тримати синхронно з C#-record'ами.

export type TapRejectReason = 'RoomNotFound' | 'UserNotFound' | 'AlreadyTapped';

export interface TapRequest {
  roomCode: string;
  userId: string;
}

export interface TapResult {
  success: boolean;
  reason: TapRejectReason | null;
  message: string | null;
  tapId: string | null;
}

export interface TapDto {
  id: string;
  fullName: string;
  groupName: string;
  createdAt: string; // ISO 8601 (DateTimeOffset)
}

export interface TapListDto {
  taps: TapDto[];
}
