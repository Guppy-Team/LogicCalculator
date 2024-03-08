import React from 'react';

import styles from './LexemeTable.module.scss';
import clsx from 'clsx';

export const LexemeTable = ({ lexemes, className }) => {
  return (
    <table className={clsx(styles.root, className)}>
      <thead>
        <tr>
          <td>Токен</td>
          <td>Тип</td>
          <td>Приоритет</td>
        </tr>
      </thead>
      <tbody>
        {lexemes.map((lexeme, i) => (
          <tr key={i}>
            <td>{lexeme.value}</td>
            <td>{lexeme.type}</td>
            <td>{lexeme.priority}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};
