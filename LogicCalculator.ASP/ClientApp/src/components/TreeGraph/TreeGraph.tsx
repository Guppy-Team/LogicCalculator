import { Loader } from '@mantine/core';
import clsx from 'clsx';
import React, { useEffect, useState } from 'react';
import Tree, { TreeNodeDatum } from 'react-d3-tree';
import { useSelector, TypedUseSelectorHook } from 'react-redux';
import { convertToRpn } from '../../api/convertToRpn';
import { rpnToTreeData } from '../../utils/rpnToTreeData';

import styles from './TreeGraph.module.scss';

interface TreeGraphProps {
  className?: string;
}

interface ReduxState {
  calculator: {
    expression: string;
  };
}

const useTypedSelector: TypedUseSelectorHook<ReduxState> = useSelector;

export const TreeGraph: React.FC<TreeGraphProps> = ({ className }) => {
  const [loading, setLoading] = useState(true);
  const { expression } = useTypedSelector((state) => state.calculator);

  const [treeData, setTreeData] = useState<TreeNodeDatum[]>([]);

  useEffect(() => {
    const fetchTreeData = async () => {
      try {
        const response = await convertToRpn(expression);
        if (response.error) {
          console.log(response.error);
          setLoading(false);
        } else {
          setTreeData([rpnToTreeData(response.result!)]);
          setLoading(false);
        }
      } catch (error) {
        console.log(error);
        setLoading(false);
      }
    };

    fetchTreeData();
  }, [expression]);

  return loading ? (
    <Loader />
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

interface CustomNodeLabelProps {
  nodeDatum: {
    name: string;
  };
  toggleNode: () => void;
}

const CustomNodeLabel: React.FC<CustomNodeLabelProps> = ({
  nodeDatum,
  toggleNode,
}) => {
  return (
    <g>
      <circle r="24" fill="steelblue" onClick={toggleNode} />
      <text textAnchor="middle" y="7" className={styles.nodeLabel}>
        {nodeDatum.name}
      </text>
    </g>
  );
};
