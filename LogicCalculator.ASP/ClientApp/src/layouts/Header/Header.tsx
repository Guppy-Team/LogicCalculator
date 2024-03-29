import React from 'react';

import styles from './Header.module.scss';
import { Link } from 'react-router-dom';

export const Header: React.FC = () => {
  return (
    <header className={styles.root}>
      <div className={styles.wrapper}>
        <Link to="/" className={styles.logo}>
          Team Guppy
        </Link>

        <nav className={styles.menu}>
          <Link to="/about" className={styles.menuLink}>
            О проекте
          </Link>
        </nav>
      </div>
    </header>
  );
};
