import clsx from 'clsx';
import React, { useState } from 'react';

import { Title } from '../../components/Title';
import { Button } from '../../components/Button';
import { InputField } from '../../components/InputField';
import { LexemeTable } from '../../components/LexemeTable';
import { TruthTable } from '../../components/TruthTable';

import styles from './Home.module.scss';

export const Home = () => {
  const [expression, setExpression] = useState('');
  const [variables, setVariables] = useState('');
  const [isVariablesVisible, setVariablesVisible] = useState(false);
  const [result, setResult] = useState('');

  const [lexemes, setLexemes] = useState([]);
  const [truthTableVariables, setTruthTableVariables] = useState([]);
  const [values, setValues] = useState([]);

  const handleCreateLexemeList = () => {
    console.log('список лексем');

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
  };

  const handleToggleVariablesVisibility = () => {
    setVariablesVisible(!isVariablesVisible);
  };

  const handleCalculate = () => {
    console.log('результат зависит от типа выражения');

    setResult('тут будет результат выполнения');
  };

  return (
    <>
      <Title>Интерпретация арифмитических выражений</Title>
      <p className={styles.subtitle}>
        Арифметические выражения, содержащие имена переменных, константы,
        <br />
        соединённые знаками бинарных операций <span>(+, -, *, /)</span> и
        скобками
      </p>

      <div className={styles.columnsWrapper}>
        <div className={styles.inputWrapper}>
          <InputField
            as="textarea"
            placeholder="Введите выражение"
            className={styles.input}
            value={expression}
            onChange={setExpression}
          />

          <div className={styles.buttonGroup}>
            <Button onClick={handleToggleVariablesVisibility}>
              {isVariablesVisible ? 'Убрать переменные' : 'Добавить переменные'}
            </Button>

            <Button
              onClick={handleCalculate}
              main
              disabled={expression.trim().length === 0}
            >
              Вычислить
            </Button>
          </div>

          {isVariablesVisible && (
            <div className={styles.variablesWrapper}>
              <p className={styles.inputLabel}>
                Введите переменные в виде <span>a = 12; b = -2;</span>:
              </p>

              <InputField
                as="textarea"
                value={variables}
                placeholder="a = 12; b = -2; c = 55;"
                className={styles.input}
                onChange={setVariables}
              />
            </div>
          )}

          {result && (
            <div className={styles.resultWrapper}>
              <p className={styles.inputLabel}>Результат:</p>

              <InputField
                as="textarea"
                value={result}
                disabled
                className={clsx(styles.input, styles.resultInput)}
              />
            </div>
          )}
        </div>

        <div className={styles.lexemeTableWrapper}>
          <Button onClick={handleCreateLexemeList}>
            Создать список лексем
          </Button>
          {lexemes.length > 0 && (
            <LexemeTable lexemes={lexemes} className={styles.lexemeTable} />
          )}
        </div>
      </div>

      <Button
        onClick={() => {
          setTruthTableVariables(['a', 'b']);
          setValues([
            { a: false, b: false, result: false },
            { a: false, b: true, result: false },
            { a: true, b: false, result: false },
            { a: true, b: true, result: true },
          ]);
          setExpression('a && b');
        }}
      >
        тест таблицы истинности
      </Button>

      {values.length > 0 && (
        <>
          <h2>Таблица истинности</h2>

          <TruthTable
            expression={expression}
            variables={truthTableVariables}
            values={values}
          />
        </>
      )}
    </>
  );
};
