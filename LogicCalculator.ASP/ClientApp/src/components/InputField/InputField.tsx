import clsx from 'clsx';
import React from 'react';

import styles from './InputField.module.scss';

interface InputFieldProps {
  as?: 'input' | 'textarea';
  className?: string;
  type?: 'text' | 'number' | 'password' | 'email' | 'search';
  value: string;
  onChange?: (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => void;
  placeholder?: string;
  disabled?: boolean;
}

export const InputField: React.FC<InputFieldProps> = ({
  as = 'input',
  className,
  type = 'text',
  value,
  onChange,
  disabled,
  ...props
}) => {
  const handleChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    onChange?.(event);
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
