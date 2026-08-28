export const theme = {
  colors: {
    bg: '#0f1115',
    card: '#1a1d24',
    inset: '#12151b',
    text: '#e7e9ee',
    muted: '#9aa0ac',
    border: '#2a2e37',
    primary: '#4f7cff',
    primaryPress: '#3d63d6',
    success: '#1f8f5f',
    successText: '#74e0ab',
    error: '#c0392b',
    errorText: '#f2938a',
    info: '#b8860b',
    infoText: '#e8c96b',
  },
  radius: {
    sm: '5px',
    md: '10px',
    lg: '16px',
  },
} as const;

export type AppTheme = typeof theme;
