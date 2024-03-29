import React from 'react';

import styles from './Title.module.scss';

interface TitleProps {
  children: string;
}

export const Title: React.FC<TitleProps> = ({ children }) => {
  return <h1 className={styles.root}>{children}</h1>;
};
