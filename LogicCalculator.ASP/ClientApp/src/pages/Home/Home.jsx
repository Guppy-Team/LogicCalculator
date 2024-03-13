import clsx from 'clsx';
import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { setExpression } from '../../store/expressionSlice';

import { Title } from '../../components/Title';
import { Button } from '../../components/Button';
import { InputField } from '../../components/InputField';
import { LexemeTable } from '../../components/LexemeTable';
import { TruthTable } from '../../components/TruthTable';
import { TreeGraph } from '../../components/TreeGraph';

import styles from './Home.module.scss';

export const Home = () => {
  const dispatch = useDispatch();
  const result = useSelector((state) => state.result);

  const [expressionValue, setExpressionValue] = useState('');
  const [variablesValue, setVariablesValue] = useState('');

  const [isVariablesVisible, setVariablesVisible] = useState(false);
  const [isTruthTableVisible, setTruthTableVisible] = useState(false);
  const [isLexemeTableVisible, setLexemeTableVisible] = useState(false);
  const [isTreeGraphVisible, setTreeGraphVisible] = useState(false);

  const handleToggleVariablesVisibility = () => {
    setVariablesVisible(!isVariablesVisible);
  };

  const calculateExpression = () => {
    dispatch(setExpression(expressionValue.trim()));
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
        <section className={styles.inputWrapper}>
          <InputField
            as="textarea"
            placeholder="Введите выражение"
            className={styles.input}
            value={expressionValue}
            onChange={setExpressionValue}
          />

          <div className={styles.buttonGroup}>
            <Button onClick={handleToggleVariablesVisibility}>
              {isVariablesVisible ? 'Убрать переменные' : 'Добавить переменные'}
            </Button>

            <Button
              onClick={() => {
                setTruthTableVisible(true);
              }}
            >
              Создать таблицу истинности
            </Button>

            <Button
              onClick={() => {
                dispatch(setExpression(expressionValue.trim()));
                setTreeGraphVisible(true);
              }}
            >
              Построить дерево лексем
            </Button>

            <Button
              onClick={() => {
                setTreeGraphVisible(true);
              }}
            >
              ПОЛИЗ
            </Button>

            <Button
              onClick={calculateExpression}
              main
              disabled={expressionValue.trim().length === 0}
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
                value={variablesValue}
                placeholder="a = 12; b = -2; c = 55;"
                className={styles.input}
                onChange={setVariablesValue}
              />
            </div>
          )}

          {/* {result && (
            <div className={styles.resultWrapper}>
              <p className={styles.inputLabel}>Результат:</p>

              <InputField
                as="textarea"
                value={result}
                disabled
                className={clsx(styles.input, styles.resultInput)}
              />
            </div>
          )} */}
        </section>

        <section className={styles.lexemeTableWrapper}>
          <Button onClick={() => setLexemeTableVisible(true)}>
            Создать список лексем
          </Button>

          {isLexemeTableVisible && (
            <LexemeTable className={styles.lexemeTable} />
          )}
        </section>

        {isTruthTableVisible && (
          <section className={styles.truthTableWrapper}>
            <>
              <TruthTable />
            </>
          </section>
        )}

        {isTreeGraphVisible && (
          <section className={styles.treeGraphWrapper}>
            <TreeGraph />
          </section>
        )}
      </div>
    </>
  );
};
