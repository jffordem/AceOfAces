// src/components/CockpitView.tsx

import { useState, useEffect } from 'react';

interface CockpitViewProps {
  page: number;
}

const CockpitView: React.FC<CockpitViewProps> = ({ page }) => {
  const [src, setSrc] = useState(`/images/allies_${page}.png`);
  const [failed, setFailed] = useState(false);

  useEffect(() => {
    setSrc(`/images/allies_${page}.png`);
    setFailed(false);
  }, [page]);

  const handleError = () => {
    if (src.endsWith('.png')) {
      setSrc(`/images/allies_${page}.jpg`);
      return;
    }

    setFailed(true);
  };

  return (
    <div className="cockpit-view">
      {!failed ? (
        <img
          src={src}
          alt={`Cockpit view page ${page}`}
          onError={handleError}
        />
      ) : (
        <div className="placeholder">Cockpit View - Page {page} (Image not available)</div>
      )}
    </div>
  );
};

export default CockpitView;