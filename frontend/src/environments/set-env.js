const fs = require('fs');
const targetPath = './src/environments/environment.prod.ts';

const apiUrl = process.env.API_URL || 'http://localhost:5278';

const envConfigFile = `export const environment = {
  production: true,
  apiUrl: '${apiUrl}'
};
`;

fs.writeFileSync(targetPath, envConfigFile);
console.log(`Wygenerowano ${targetPath} z apiUrl=${apiUrl}`);
