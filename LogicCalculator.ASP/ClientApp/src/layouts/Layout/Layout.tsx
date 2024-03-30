import React, { ReactNode } from 'react';
import { Container } from '@mantine/core';

import { Header } from '../Header';

import styles from './Layout.module.scss';

interface LayoutProps {
  children: ReactNode;
}

export const Layout: React.FC<LayoutProps> = ({ children }) => {
  return (
    <div className={styles.wrapper}>
      <Header />
      <main>
        <Container>{children}</Container>
      </main>
    </div>
  );
};
