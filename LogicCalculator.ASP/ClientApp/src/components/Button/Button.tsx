import clsx from 'clsx';
import React from 'react';

import styles from './Button.module.scss';

interface ButtonProps {
  onClick: (event: React.MouseEvent<HTMLButtonElement>) => void;
  children: string;
  className?: string;
  main?: boolean;
  disabled?: boolean;
}

export const Button: React.FC<ButtonProps> = ({
  onClick,
  children,
  className,
  main,
  ...props
}) => {
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
