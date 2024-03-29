import React from 'react';

import styles from './Loading.module.scss';

export const Loading = () => {
  return (
    <div className={styles.root}>
      <div className={styles.spinner}></div>
    </div>
  );
};
