import clsx from 'clsx';
import React, { useEffect, useState } from 'react';

import styles from './LexemeTable.module.scss';
import { Loading } from '../Loading';

export const LexemeTable = ({ className }) => {
  const [loading, setLoading] = useState(true);
  const [lexemes, setLexemes] = useState([]);

  useEffect(() => {
    setTimeout(() => {
      setLexemes([
        { value: '1', type: 'number', priority: '0' },
        { value: '/', type: 'sign', priority: '2' },
        { value: '2', type: 'number', priority: '0' },
        { value: '+', type: 'sign', priority: '1' },
        { value: '(', type: 'left_bracket', priority: '3' },
        { value: '2', type: 'number', priority: '0' },
        { value: '+', type: 'sign', priority: '1' },
        { value: '3', type: 'number', priority: '0' },
        { value: ')', type: 'right_bracket', priority: '3' },
      ]);

      setLoading(false);
    }, 1500);
  }, []);

  const table = (
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

  return loading ? <Loading /> : table;
};
