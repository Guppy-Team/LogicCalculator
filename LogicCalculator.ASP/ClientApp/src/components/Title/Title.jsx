import React from 'react';

import styles from './Title.module.scss';

export const Title = ({ children }) => {
  return <h1 className={styles.root}>{children}</h1>;
};
