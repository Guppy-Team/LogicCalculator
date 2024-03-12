import clsx from 'clsx';
import React, { useEffect, useState } from 'react';

import styles from './TruthTable.module.scss';
import { Loading } from '../Loading';

export const TruthTable = () => {
  const [loading, setLoading] = useState(true);
  const [variables, setVariables] = useState([]);
  const [values, setValues] = useState([]);
  const [expression, setExpression] = useState('');

  const generateTruthTable = () => {
    // TODO: переделать генерацию таблицы
    // Логика для генерации таблицы истинности на основе выражения и переменных
    // Возвращает массив строк таблицы истинности
    const truthTableRows = [];

    values.forEach((value) => {
      const row = (
        <tr key={`${value.a}-${value.b}`}>
          <td className={clsx(value.a ? styles.true : styles.false)}>
            {value.a.toString()}
          </td>
          <td className={clsx(value.b ? styles.true : styles.false)}>
            {value.b.toString()}
          </td>
          <td className={clsx(value.c ? styles.true : styles.false)}>
            {value.c.toString()}
          </td>
          <td className={clsx(value.result ? styles.true : styles.false)}>
            {value.result.toString()}
          </td>
        </tr>
      );
      truthTableRows.push(row);
    });

    return truthTableRows;
  };

  const truthTableRows = generateTruthTable();

  useEffect(() => {
    setTimeout(() => {
      setVariables(['a', 'b', 'c']);
      setValues([
        { a: false, b: false, c: false, result: true },
        { a: false, b: false, c: true, result: true },
        { a: false, b: true, c: false, result: false },
        { a: false, b: true, c: true, result: true },
        { a: true, b: false, c: false, result: true },
        { a: true, b: false, c: true, result: true },
        { a: true, b: true, c: false, result: true },
        { a: true, b: true, c: true, result: true },
      ]);
      setExpression('a ∨ (b → c)');

      setLoading(false);
    }, 1500);
  }, []);

  const table = (
    <>
      <h2 className={styles.title}>Таблица истинности</h2>

      <table className={styles.root}>
        <thead>
          <tr>
            {variables.map((variable) => (
              <th key={variable}>{variable}</th>
            ))}

            <th>{expression}</th>
          </tr>
        </thead>

        <tbody>{truthTableRows}</tbody>
      </table>
    </>
  );

  return loading ? <Loading /> : table;
};
