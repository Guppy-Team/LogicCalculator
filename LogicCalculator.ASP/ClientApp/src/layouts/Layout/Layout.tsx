import React, { ReactNode } from 'react';

import styles from './Layout.module.scss';

import { Header } from '../Header';

interface LayoutProps {
  children: ReactNode;
}

export const Layout: React.FC<LayoutProps> = ({ children }) => {
  return (
    <div className={styles.wrapper}>
      <Header />
      <main>
        <div className={styles.container}>{children}</div>
      </main>
    </div>
  );
};
