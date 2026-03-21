// src/components/CockpitView.tsx

import React from 'react';

interface CockpitViewProps {
  page: number;
}

const CockpitView: React.FC<CockpitViewProps> = ({ page }) => {
  // Placeholder for image. In real app, load from public/images/allies_${page}.png
  return (
    <div className="cockpit-view">
      <img
        src={`/images/allies_${page}.png`}
        alt={`Cockpit view page ${page}`}
        onError={(e) => {
          e.currentTarget.style.display = 'none';
          const parent = e.currentTarget.parentElement;
          if (parent && !parent.querySelector('.placeholder')) {
            const placeholder = document.createElement('div');
            placeholder.className = 'placeholder';
            placeholder.textContent = `Cockpit View - Page ${page} (Image not available)`;
            placeholder.style.padding = '2rem';
            placeholder.style.border = '2px solid #333';
            placeholder.style.borderRadius = '8px';
            placeholder.style.backgroundColor = '#f9f9f9';
            parent.appendChild(placeholder);
          }
        }}
      />
    </div>
  );
};

export default CockpitView;