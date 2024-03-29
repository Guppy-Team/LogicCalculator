import { TreeNodeDatum } from 'react-d3-tree';

export function rpnToTreeData(rpn: string): RpnTreeData {
  const stack: (RpnTreeData | { name: string })[] = [];
  const isVariable = (token: string) => /^[a-zA-Z]$/.test(token);
  const isNumber = (token: string) => !isNaN(parseFloat(token));

  for (let token of rpn.split(' ')) {
    if (['+', '-', '*', '/', '^'].includes(token)) {
      const right = stack.pop() as RpnTreeData;
      const left = stack.pop() as RpnTreeData;
      stack.push({
        name: token,
        children: [left, right],
      });
    } else if (['sin', 'cos', 'tan', 'log', 'exp'].includes(token)) {
      const child = stack.pop() as RpnTreeData;
      stack.push({
        name: token,
        children: [child],
      });
    } else if (isVariable(token) || isNumber(token)) {
      stack.push({
        name: token,
      });
    }
  }

  return stack[0] as RpnTreeData;
}

export interface RpnTreeData extends TreeNodeDatum {
  name: string;
  children?: RpnTreeData[];
}
