// src/components/CockpitView.tsx

import React from 'react';

interface CockpitViewProps {
  page: number;
}

const CockpitView: React.FC<CockpitViewProps> = ({ page }) => {
  // Placeholder for image. In real app, load from public/images/allies_${page}.png
  return (
    <div className="cockpit-view">
      <img src={`/images/allies_${page}.png`} alt={`Cockpit view page ${page}`} />
    </div>
  );
};

export default CockpitView;