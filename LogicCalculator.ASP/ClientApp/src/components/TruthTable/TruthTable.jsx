import React from 'react';

import styles from './TruthTable.module.scss';
import clsx from 'clsx';

export const TruthTable = ({ expression, variables, values }) => {
  const generateTruthTable = () => {
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

  return (
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
  );
};
