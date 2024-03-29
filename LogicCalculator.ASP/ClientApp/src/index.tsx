import React, { StrictMode } from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import {
  MantineProvider,
  MantineColorsTuple,
  createTheme,
} from '@mantine/core';

import store from './store/store';

import '@mantine/core/styles.css';

// import './scss/main.scss';

import App from './App';

const myColor: MantineColorsTuple = [
  '#f1f3f8',
  '#e0e2ea',
  '#bfc2d6',
  '#9ba1c2',
  '#7d84b2',
  '#6972a9',
  '#5f69a5',
  '#505990',
  '#454f82',
  '#3a4474',
];

const theme = createTheme({
  fontFamily: "Inter, sans-serif",
  colors: {
    myColor,
  },
});

const baseUrl =
  document.getElementsByTagName('base')[0]?.getAttribute('href') || '/';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);
root.render(
  <StrictMode>
    <BrowserRouter basename={baseUrl}>
      <Provider store={store}>
        <MantineProvider defaultColorScheme='dark' theme={theme}>
          <App />
        </MantineProvider>
      </Provider>
    </BrowserRouter>
  </StrictMode>,
);
