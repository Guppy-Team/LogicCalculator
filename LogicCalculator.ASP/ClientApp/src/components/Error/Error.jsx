import React from 'react';
import { useDispatch } from 'react-redux';
import { closeError } from '../../store/calculatorSlice';

import styles from './Error.module.scss';

export const Error = ({ message }) => {
  const dispatch = useDispatch();

  const handleCloseError = () => {
    dispatch(closeError(false));
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
