import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Group } from '@mantine/core';

import styles from './Header.module.scss';

const links = [{ link: '/about', label: 'О проекте' }];

export const Header: React.FC = () => {
  const items = links.map((link) => {
    return (
      <Link key={link.label} to={link.link} className={styles.link}>
        {link.label}
      </Link>
    );
  });

  return (
    <header className={styles.header}>
      <Container size="md">
        <div className={styles.inner}>
          <Link to="/" className={styles.logo}>
            Team Guppy
          </Link>

          <Group gap={5}>{items}</Group>
        </div>
      </Container>
    </header>
  );
};
