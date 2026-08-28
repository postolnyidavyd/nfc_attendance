import 'styled-components';
import type { AppTheme } from './theme';

// Робить props.theme типізованим у всіх styled-компонентах.
declare module 'styled-components' {
  // eslint-disable-next-line @typescript-eslint/no-empty-object-type
  export interface DefaultTheme extends AppTheme {}
}
