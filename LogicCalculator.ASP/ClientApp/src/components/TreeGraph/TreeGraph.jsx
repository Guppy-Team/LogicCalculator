import React, { useEffect, useState } from 'react';
import Tree from 'react-d3-tree';
import { useSelector } from 'react-redux';

import { Loading } from '../Loading';

import styles from './TreeGraph.module.scss';

const CustomNodeLabel = ({ nodeDatum, toggleNode }) => {
  return (
    <g>
      <circle r="24" fill="steelblue" onClick={toggleNode} />
      <text textAnchor="middle" y="7" className={styles.nodeLabel}>
        {nodeDatum.name}
      </text>
    </g>
  );
};

export const TreeGraph = () => {
  const [loading, setLoading] = useState(true);
  const { expression } = useSelector((state) => state.expression);

  const [data, setData] = useState({});

  useEffect(() => {
    setTimeout(() => {
      setData(rpnToTreeData(expression));
      setLoading(false);
    }, 1500);
  }, [expression]);

  console.log(expression);

  function rpnToTreeData(rpn) {
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

  return loading ? (
    <Loading />
  ) : (
    <div className={styles.root}>
      <h2 className={styles.title}>Дерево лексем</h2>
      <div className={styles.graphContainer}>
        <Tree
          data={data}
          orientation="vertical"
          pathFunc="straight"
          collapsible={false}
          zoom={0.7}
          translate={{
            x: 170,
            y: 50,
          }}
          nodeSize={{ x: 80, y: 100 }}
          renderCustomNodeElement={({ nodeDatum, toggleNode }) => (
            <CustomNodeLabel nodeDatum={nodeDatum} toggleNode={toggleNode} />
          )}
        />
      </div>
    </div>
  );
};
