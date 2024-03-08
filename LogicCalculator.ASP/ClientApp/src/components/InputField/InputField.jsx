import React, { useState } from 'react';
import clsx from 'clsx';

import styles from './InputField.module.scss';

export const InputField = ({
  as = 'input',
  className,
  type = 'text',
  value,
  onChange,
  disabled,
  ...props
}) => {
  const handleChange = (event) => {
    onChange(event.target.value);
  };

  const combinedClassName = clsx(styles.root, className);

  return as === 'textarea' ? (
    <textarea
      value={value}
      disabled={disabled}
      onChange={handleChange}
      className={combinedClassName}
      {...props}
    />
  ) : (
    <input
      value={value}
      disabled={disabled}
      onChange={handleChange}
      className={combinedClassName}
      type={type}
      {...props}
    />
  );
};
