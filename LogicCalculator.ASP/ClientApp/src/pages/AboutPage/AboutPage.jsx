import React from 'react';

import styles from './AboutPage.module.scss';
import { Title } from '../../components/Title';

export const AboutPage = () => {
  return (
    <div className={styles.root}>
      <Title>О проекте</Title>
    </div>
  );
};
