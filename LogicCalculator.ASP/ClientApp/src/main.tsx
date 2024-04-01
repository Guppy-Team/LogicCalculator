import { createTheme, MantineProvider, rem } from '@mantine/core';
import { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';

import store from './store/store';

import '@mantine/core/styles.css';

import App from './App';

const theme = createTheme({
  fontFamily: 'Inter, sans-serif',
  fontSizes: {
    xs: rem(12),
    sm: rem(16),
    md: rem(18),
    lg: rem(20),
    xl: rem(24),
  },
});

const baseUrl = document.getElementsByTagName('base')[0]?.getAttribute('href') || '/';

ReactDOM.createRoot(document.getElementById('root')! as HTMLElement).render(
  <StrictMode>
    <BrowserRouter basename={baseUrl}>
      <Provider store={store}>
        <MantineProvider defaultColorScheme="light" theme={theme}>
          <App />
        </MantineProvider>
      </Provider>
    </BrowserRouter>
  </StrictMode>,
);
