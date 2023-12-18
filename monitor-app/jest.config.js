/* eslint-disable no-undef */
/** @type {import('ts-jest').JestConfigWithTsJest} */
module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'node',
  automock: true,
  testPathIgnorePatterns: ['/node_modules/', '/dist/'],
};
