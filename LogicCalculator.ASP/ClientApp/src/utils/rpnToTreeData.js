export function rpnToTreeData(rpn) {
  const stack = [];
  const isVariable = (token) => /^[a-zA-Z]$/.test(token);

  for (let token of rpn.split(' ')) {
    if (['+', '-', '*', '/', '^'].includes(token)) {
      const right = stack.pop();
      const left = stack.pop();
      stack.push({
        name: token,
        children: [left, right],
      });
    } else if (['sin', 'cos', 'tan', 'log', 'exp'].includes(token)) {
      const child = stack.pop();
      stack.push({
        name: token,
        children: [child],
      });
    } else if (isVariable(token) || !isNaN(token)) {
      stack.push({
        name: token,
      });
    }
  }

  return stack[0];
}
