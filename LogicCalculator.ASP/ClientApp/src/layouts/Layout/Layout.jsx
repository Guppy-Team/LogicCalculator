import React from 'react';

import styles from './Layout.module.scss';

import { Header } from '../Header';

export const Layout = ({ children }) => {
  return (
    <div className={styles.wrapper}>
      <Header />
      <main>
        <div className={styles.container}>{children}</div>
      </main>
    </div>
  );
};
