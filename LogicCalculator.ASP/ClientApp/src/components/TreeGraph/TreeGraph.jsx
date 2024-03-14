import clsx from 'clsx';
import React, { useEffect, useState } from 'react';
import Tree from 'react-d3-tree';
import { useSelector } from 'react-redux';
import { convertToRpn } from '../../api/convertToRpn';
import { rpnToTreeData } from '../../utils/rpnToTreeData';

import { Loading } from '../Loading';

import styles from './TreeGraph.module.scss';

export const TreeGraph = ({ className }) => {
  const [loading, setLoading] = useState(true);
  const { expression } = useSelector((state) => state.calculator);

  const [treeData, setTreeData] = useState({});

  useEffect(() => {
    const fetchTreeData = async () => {
      try {
        const rpn = await convertToRpn(expression);
        setTreeData(rpnToTreeData(rpn));
        setLoading(false);
      } catch (error) {
        console.log(error);
        setLoading(false);
      }
    };

    fetchTreeData();
  }, [expression]);

  return loading ? (
    <Loading />
  ) : (
    <section className={clsx(styles.root, className)}>
      <h2 className={styles.title}>Дерево лексем</h2>
      <div className={styles.graphContainer}>
        <Tree
          data={treeData}
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
    </section>
  );
};

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
