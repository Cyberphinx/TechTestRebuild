import 'isomorphic-fetch';
import { Aurelia } from 'aurelia-framework';
import * as environment from '../config/environment.json';
import { PLATFORM } from 'aurelia-pal';
import { HttpClient } from 'aurelia-fetch-client';
import { Repeat } from 'aurelia-templating-resources';

import 'bulma/css/bulma.css';

// added below line to fix an Aurelia bug with the repeater/matcher combo in colour checkbox of person-edit.html
Repeat.useInnerMatcher = false;

export function configure(aurelia: Aurelia) {

  const http = new HttpClient();
  http.configure(config => {
    config
      .useStandardConfiguration()
      .withDefaults({ headers: { 'Accept': 'application/json' } })
      .withBaseUrl('https://localhost:5001/api');
  });

  aurelia.use
    .instance(HttpClient, http)
    .standardConfiguration()
    .globalResources(PLATFORM.moduleName('shared/colour-names-value-converter'));

  
  if (environment.testing) {
    aurelia.use.plugin(PLATFORM.moduleName('aurelia-testing'));
  }

  new HttpClient().configure(config => {
    const baseUrl = document.getElementsByTagName('base')[0].href;
    config.withBaseUrl(baseUrl);
  });


  aurelia.start().then(() => aurelia.setRoot(PLATFORM.moduleName('app')));
}
