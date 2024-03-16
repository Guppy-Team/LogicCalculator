import React from 'react';

import styles from './Button.module.scss';
import clsx from 'clsx';

export const Button = ({ onClick, children, className, main, ...props }) => {
  return (
    <button
      onClick={onClick}
      className={clsx(styles.root, main && styles.main, className)}
      {...props}
    >
      {children}
    </button>
  );
};
