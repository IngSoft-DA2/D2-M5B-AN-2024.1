import { PrettyDataPipe } from './pretty-data.pipe';

describe('PrettyDataPipe', () => {
  it('create an instance', () => {
    const pipe = new PrettyDataPipe();
    expect(pipe).toBeTruthy();
  });
});
