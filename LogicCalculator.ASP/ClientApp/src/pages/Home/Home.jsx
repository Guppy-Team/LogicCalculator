import clsx from 'clsx';
import React, { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { convertToRpn } from '../../store/calculatorAction';
import {
  showError,
  setExpression,
  closeError,
} from '../../store/calculatorSlice';

import { Title } from '../../components/Title';
import { Button } from '../../components/Button';
import { InputField } from '../../components/InputField';
import { LexemeTable } from '../../components/LexemeTable';
import { TruthTable } from '../../components/TruthTable';
import { TreeGraph } from '../../components/TreeGraph';
import { Error } from '../../components/Error';

import styles from './Home.module.scss';
import { isValidExpression } from '../../utils/isValidExpression';

export const Home = () => {
  const dispatch = useDispatch();
  const { result, error } = useSelector((state) => state.calculator);

  const [expressionValue, setExpressionValue] = useState('');
  const [variablesValue, setVariablesValue] = useState('');

  const [showVariables, setShowVariables] = useState(false);
  const [showTruthTable, setShowTruthTable] = useState(false);
  const [showLexemeTable, setShowLexemeTable] = useState(false);
  const [showTreeGraph, setShowTreeGraph] = useState(false);

  const handleToggleVariables = () => {
    setShowVariables(!showVariables);
  };

  const handleCalculateExpression = () => {
    const trimmedExpression = expressionValue.trim();

    if (trimmedExpression.length === 0) {
      dispatch(
        showError(
          'Укажите верное выражение в поле выше, а затем попробуйте снова.',
        ),
      );

      setTimeout(() => {
        dispatch(closeError());
      }, 7500);
    } else {
      const formattedExpression = trimmedExpression.replace(/\s+/g, ' ');
      setShowTreeGraph(false);
      dispatch(convertToRpn(formattedExpression));
    }
  };

  const handleConvertToRpn = () => {
    const trimmedExpression = expressionValue.trim();

    if (trimmedExpression.length === 0) {
      dispatch(
        showError(
          'Укажите верное выражение в поле выше, а затем попробуйте снова.',
        ),
      );

      setTimeout(() => {
        dispatch(closeError());
      }, 7500);
    } else {
      const formattedExpression = trimmedExpression.replace(/\s+/g, ' ');

      if (isValidExpression(formattedExpression)) {
        setShowTreeGraph(false);
        dispatch(convertToRpn(formattedExpression));
      } else {
        dispatch(
          showError(
            'Выражение не может быть переведено в обратную польскую нотацию. Проверьте корректность выражения.',
          ),
        );

        setTimeout(() => {
          dispatch(closeError());
        }, 7500);
      }
    }
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
            <Button onClick={handleToggleVariables}>
              {showVariables ? 'Убрать переменные' : 'Добавить переменные'}
            </Button>

            <Button
              onClick={() => {
                setShowTruthTable(true);
              }}
            >
              Создать таблицу истинности
            </Button>

            <Button onClick={handleConvertToRpn}>ПОЛИЗ</Button>

            <Button
              onClick={() => {
                dispatch(setExpression(expressionValue.trim()));
                setShowTreeGraph(!showTreeGraph);
              }}
              disabled={expressionValue.trim() === '' ? true : false}
            >
              {showTreeGraph
                ? 'Скрыть дерево лексем'
                : 'Показать дерево лексем'}
            </Button>

            <Button
              onClick={handleCalculateExpression}
              main
              disabled={expressionValue.trim().length === 0}
            >
              Вычислить
            </Button>
          </div>

          {showVariables && (
            <section className={styles.variablesWrapper}>
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
            </section>
          )}

          {result && (
            <section className={styles.resultWrapper}>
              <p className={styles.inputLabel}>Результат:</p>

              <InputField
                as="textarea"
                value={result}
                disabled
                className={clsx(styles.input, styles.resultInput)}
              />
            </section>
          )}

          {error && <Error message={error} />}
        </section>

        <section className={styles.lexemeTableWrapper}>
          <Button onClick={() => setShowLexemeTable(true)}>
            Создать список лексем
          </Button>

          {showLexemeTable && <LexemeTable className={styles.lexemeTable} />}
        </section>

        {showTruthTable && <TruthTable className={styles.truthTableWrapper} />}

        {showTreeGraph && <TreeGraph className={styles.treeGraphWrapper} />}
      </div>
    </>
  );
};
