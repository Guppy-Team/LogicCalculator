import React, { useState } from 'react';

import { Button } from '../../components/Button';
import { InputField } from '../../components/InputField';
import { Title } from '../../components/Title';

import styles from './Home.module.scss';
import { LexemeTable } from '../../components/LexemeTable/LexemeTable';

export const Home = () => {
  const [expression, setExpression] = useState('');
  const [variables, setVariables] = useState('');
  const [isVariablesVisible, setVariablesVisible] = useState(false);
  const [result, setResult] = useState('');

  const [lexemes, setLexemes] = useState([]);

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
              <p className={styles.variablesDescr}>
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
    </>
  );
};
