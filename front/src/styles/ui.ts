import { Link } from 'react-router-dom';
import styled, { css } from 'styled-components';

export const Card = styled.main`
  width: 100%;
  max-width: 480px;
  background: ${({ theme }) => theme.colors.card};
  border: 1px solid ${({ theme }) => theme.colors.border};
  border-radius: ${({ theme }) => theme.radius.lg};
  padding: 1.75rem;
  display: flex;
  flex-direction: column;
  gap: 1rem;
`;

export const Eyebrow = styled.p`
  margin: 0;
  text-transform: uppercase;
  letter-spacing: 0.08em;
  font-size: 0.75rem;
  color: ${({ theme }) => theme.colors.muted};
`;

export const Title = styled.h1`
  margin: 0;
  font-size: 1.5rem;
`;

export const RoomCode = styled.h1`
  margin: 0;
  font-size: 2.75rem;
  font-weight: 700;
  letter-spacing: 0.02em;
`;

export const Muted = styled.p`
  margin: 0;
  color: ${({ theme }) => theme.colors.muted};
`;

export const Field = styled.label`
  display: flex;
  flex-direction: column;
  gap: 0.4rem;
  font-size: 0.9rem;
  color: ${({ theme }) => theme.colors.muted};
`;

export const Select = styled.select`
  padding: 0.7rem 0.75rem;
  font-size: 1rem;
  background: ${({ theme }) => theme.colors.inset};
  color: ${({ theme }) => theme.colors.text};
  border: 1px solid ${({ theme }) => theme.colors.border};
  border-radius: ${({ theme }) => theme.radius.md};
`;

export const PrimaryButton = styled.button`
  padding: 0.85rem 1rem;
  font-size: 1rem;
  font-weight: 600;
  color: #fff;
  background: ${({ theme }) => theme.colors.primary};
  border: none;
  border-radius: ${({ theme }) => theme.radius.md};
  cursor: pointer;
  transition: background 0.15s ease;

  &:hover:not(:disabled) {
    background: ${({ theme }) => theme.colors.primaryPress};
  }

  &:disabled {
    opacity: 0.6;
    cursor: default;
  }
`;

export type BannerVariant = 'success' | 'error' | 'info';

const bannerVariants = {
  success: css`
    background: rgba(31, 143, 95, 0.15);
    border-color: ${({ theme }) => theme.colors.success};
    color: ${({ theme }) => theme.colors.successText};
  `,
  error: css`
    background: rgba(192, 57, 43, 0.15);
    border-color: ${({ theme }) => theme.colors.error};
    color: ${({ theme }) => theme.colors.errorText};
  `,
  info: css`
    background: rgba(184, 134, 11, 0.15);
    border-color: ${({ theme }) => theme.colors.info};
    color: ${({ theme }) => theme.colors.infoText};
  `,
};

export const Banner = styled.div<{ $variant: BannerVariant }>`
  padding: 0.8rem 1rem;
  border: 1px solid transparent;
  border-radius: ${({ theme }) => theme.radius.md};
  font-weight: 500;
  ${({ $variant }) => bannerVariants[$variant]}
`;

export const TextLink = styled(Link)`
  color: ${({ theme }) => theme.colors.primary};
  text-decoration: none;
  font-size: 0.9rem;

  &:hover {
    text-decoration: underline;
  }
`;

export const TapsTable = styled.table`
  width: 100%;
  border-collapse: collapse;
  font-size: 0.9rem;

  th,
  td {
    text-align: left;
    padding: 0.55rem 0.5rem;
    border-bottom: 1px solid ${({ theme }) => theme.colors.border};
  }

  th {
    color: ${({ theme }) => theme.colors.muted};
    font-weight: 500;
  }
`;

export const RoomList = styled.ul`
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  flex-direction: column;
  gap: 0.6rem;

  li {
    display: flex;
    align-items: center;
    gap: 1rem;
    padding: 0.6rem 0.75rem;
    border: 1px solid ${({ theme }) => theme.colors.border};
    border-radius: ${({ theme }) => theme.radius.md};
  }
`;

export const RoomBadge = styled.span`
  font-weight: 700;
  font-size: 1.1rem;
  min-width: 2.5rem;
`;

export const Code = styled.code`
  background: ${({ theme }) => theme.colors.inset};
  padding: 0.1rem 0.35rem;
  border-radius: ${({ theme }) => theme.radius.sm};
  font-size: 0.85em;
`;
