import React, { useState } from 'react';

import { Button } from '../../components/Button';
import { InputField } from '../../components/InputField';
import { Title } from '../../components/Title';

import styles from './Home.module.scss';

export const Home = () => {
  const [expression, setExpression] = useState('');
  const [variables, setVariables] = useState('');
  const [isVariablesVisible, setVariablesVisible] = useState(false);
  const [result, setResult] = useState('');

  const handleCreateLexemeList = () => {
    console.log('список лексем');
  };

  const handleToggleVariablesVisibility = () => {
    setVariablesVisible(!isVariablesVisible);
  };

  const handleCalculate = () => {
    console.log('результат зависит от типа выражения');
  };

  return (
    <div>
      <Title>Интерпретация арифмитических выражений</Title>
      <p className={styles.subtitle}>
        Арифметические выражения, содержащие имена переменных, константы,
        <br />
        соединённые знаками бинарных операций <span>(+, -, *, /)</span> и
        скобками
      </p>

      <div className={styles.inputWrapper}>
        <InputField
          as="textarea"
          placeholder="Введите выражение"
          className={styles.input}
          value={expression}
          onChange={setExpression}
        />

        <div className={styles.buttonGroup}>
          <Button onClick={handleCreateLexemeList}>
            Создать список лексем
          </Button>

          <Button onClick={handleToggleVariablesVisibility}>
            Указать переменные
          </Button>

          <Button onClick={handleCalculate} main>
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
    </div>
  );
};
