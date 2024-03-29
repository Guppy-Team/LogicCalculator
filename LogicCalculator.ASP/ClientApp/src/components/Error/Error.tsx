import React from 'react';
import { useDispatch } from 'react-redux';
import { closeError } from '../../store/calculatorSlice';

import styles from './Error.module.scss';

interface ErrorProps {
  message: string;
}

export const Error: React.FC<ErrorProps> = ({ message }) => {
  const dispatch = useDispatch();

  const handleCloseError = () => {
    dispatch(closeError());
  };

  return (
    <p className={styles.root}>
      <span>Ошибка:</span> {message}
      <button onClick={handleCloseError} className={styles.close}>
        x
      </button>
    </p>
  );
};