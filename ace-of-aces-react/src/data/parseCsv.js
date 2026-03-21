import fs from 'fs';
import path from 'path';
import csv from 'csv-parser';
import { fileURLToPath } from 'url';

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

function parseCsv(filePath) {
  return new Promise((resolve, reject) => {
    const results = {};
    let isFirst = true;
    fs.createReadStream(filePath)
      .pipe(csv({ headers: false }))
      .on('data', (data) => {
        if (isFirst) {
          isFirst = false;
          return; // skip header
        }
        const maneuver = data[0];
        const pages = {};
        for (let i = 1; i <= 223; i++) {
          pages[i] = parseInt(data[i], 10);
        }
        results[maneuver] = pages;
      })
      .on('end', () => {
        resolve(results);
      })
      .on('error', reject);
  });
}

async function main() {
  try {
    const alliesData = await parseCsv(path.join(__dirname, 'allies.csv'));
    const germansData = await parseCsv(path.join(__dirname, 'germans.csv'));

    const output = `// Auto-generated from CSV files
export interface BookData {
  [maneuver: string]: { [page: number]: number };
}

export const alliesData: BookData = ${JSON.stringify(alliesData, null, 2)};

export const germansData: BookData = ${JSON.stringify(germansData, null, 2)};
`;

    fs.writeFileSync(path.join(__dirname, 'books.ts'), output);
    console.log('books.ts generated successfully');
  } catch (error) {
    console.error('Error parsing CSVs:', error);
  }
}

main();