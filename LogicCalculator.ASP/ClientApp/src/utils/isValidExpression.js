export const isValidExpression = (expression) => {
  const operators = ['+', '-', '*', '/', '^'];
  const stack = [];

  for (let i = 0; i < expression.length; i++) {
    const char = expression[i];

    if (char === '(') {
      stack.push(char);
    } else if (char === ')') {
      if (stack.length === 0 || stack.pop() !== '(') {
        return false;
      }
    } else if (operators.includes(char)) {
      if (
        i === 0 ||
        i === expression.length - 1 ||
        operators.includes(expression[i - 1])
      ) {
        return false;
      }
    }
  }

  return stack.length === 0;
};
