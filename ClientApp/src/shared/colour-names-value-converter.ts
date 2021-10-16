import { IColour } from '../people/interfaces/icolour';

export class ColourNamesValueConverter {

  toView(colours: IColour[]) {

    // TODO: Step 4
    //
    // Implement the value converter function.
    // Using the colours parameter, convert the list into a comma
    // separated string of colour names. The names should be sorted
    // alphabetically and there should not be a trailing comma.
    //
    // Example: 'Blue, Green, Red'

    const obj: string[] = [];
    for (let i in colours) {
      obj.push(' ' + colours[i].name);
    }

    obj.sort((a, b) => {
      if (a < b) return -1;
      if (a > b) return 1;
      return 0;
    })

    return obj;
  }

}
