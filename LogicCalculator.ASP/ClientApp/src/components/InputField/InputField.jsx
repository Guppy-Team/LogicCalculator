import React, { useState } from 'react';
import clsx from 'clsx';

import styles from './InputField.module.scss';

export const InputField = ({
  as = 'input',
  className,
  type = 'text',
  value,
  onChange,
  ...props
}) => {
  const [internalValue, setInternalValue] = useState('');

  const handleChange = (event) => {
    setInternalValue(event.target.value);
    onChange && onChange(event.target.value); // Call external handler if provided
  };

  const combinedClassName = clsx(styles.root, className);

  return as === 'textarea' ? (
    <textarea
      value={internalValue}
      onChange={handleChange}
      className={combinedClassName}
      {...props}
    />
  ) : (
    <input
      value={internalValue}
      onChange={handleChange}
      className={combinedClassName}
      type={type}
      {...props}
    />
  );
};
