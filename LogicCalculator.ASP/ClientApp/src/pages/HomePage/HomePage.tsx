import {
	Box,
	Button,
	Divider,
	Grid,
	Text,
	Textarea,
	Title
} from '@mantine/core';
import { useForm } from '@mantine/form';
import React, { useState } from 'react';

import styles from './HomePage.module.scss';

export const HomePage: React.FC = () => {
  const [showVariables, setShowVariables] = useState<boolean>(false);
  const [showResult, setShowResult] = useState<boolean>(false);

  const form = useForm({
    initialValues: {
      expression: '',
      variables: '',
    },

    validate: {
      expression: (value) =>
        /[\S\s]+[\S]+/.test(value) ? null : 'Выражение введено некорректно',
    },
  });

  const handleShowVariables = () => {
    setShowVariables(!showVariables);
  };

  return (
    <>
      <Title order={1} mb={10}>
        Интерпретация арифмитических выражений
      </Title>
      <Text className={styles.description} mb={10}>
        Арифметические выражения, содержащие имена переменных, константы,
        <br />
        соединённые знаками бинарных операций{' '}
        <span>(+,&nbsp;-,&nbsp;*,&nbsp;/)</span> и&nbsp;скобками
      </Text>
      <Divider mb={25} />

      <Grid>
        <Grid.Col span={7}>
          <form onSubmit={form.onSubmit((values) => console.log(values))}>
            <Textarea
              autosize
              minRows={3}
              maxRows={5}
              radius="md"
              mb={10}
              placeholder="Введите выражение"
              {...form.getInputProps('expression')}
            />

            {showVariables && (
              <Textarea
                label="Введите переменные в виде a = 12; b = -2;:"
                radius="md"
                mb={20}
                placeholder="a = 12; b = -2; c = 55;"
                {...form.getInputProps('variables')}
              />
            )}

            <Box mb={15}>
              <Button type="submit" radius="md">
                Вычислить
              </Button>
            </Box>
          </form>

          <Box className={styles.buttonsWrapper}>
            <Button variant="light" radius="md" onClick={handleShowVariables}>
              {showVariables ? 'Убрать переменные' : 'Добавить переменные'}
            </Button>
            <Button variant="light" radius="md">
              Создать таблицу истинности
            </Button>
            <Button variant="light" radius="md">
              ПОЛИЗ
            </Button>
            <Button variant="light" radius="md">
              Показать дерево лексем
            </Button>
          </Box>

          {showResult && <Textarea label="Результат:" radius="md" mt={20} />}
        </Grid.Col>

        <Grid.Col span="auto">
          <Button variant="light" radius="md">
            Показать список лексем
          </Button>
        </Grid.Col>
      </Grid>
    </>
  );
};
