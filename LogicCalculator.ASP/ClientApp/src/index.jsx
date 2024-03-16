import React from 'react';
import ReactDOM from 'react-dom/client';
import { Provider } from 'react-redux';
import { BrowserRouter } from 'react-router-dom';
import store from './store/store';

import './scss/main.scss';

import App from './App';

const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <BrowserRouter basename={baseUrl}>
    <Provider store={store}>
      <App />
    </Provider>
  </BrowserRouter>,
);
