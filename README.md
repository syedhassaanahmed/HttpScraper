HttpScraper
===========

Cross-platform XamarinForms App which targets UWP, Android and iOS;

- A single button to run the requests simultaneously.

- Text view for each request to be updated as soon as the processing of corresponding request finishes.

- Request: This is a type of object, which grabs some data from a web resource through an URL, 
gets the contents, holds the response in a field locally, and processes the response and prepares an output.

The Main runs 3 requests simultaneously, each request is defined below;

1) NthLetterRequest: 

 - Processes URL and finds the 10th letter in the text and reports it back to Main via callback. 

2) EveryNthLetterRequest:

 - Processes URL and finds every 10th letter(i.e: 10th, 20th, 30th etc.) in the text and reports it back to Main 
via callback.

3) WordCounterRequest

 - Processes URL, splits the text into words by using whitespace characters (i.e: space, linefeed etc.) 
and uses a simple algorithm to count every word in the document and reports it back to Main via callback. 
HTML/Javascript is disregarded. The callback brings dictionary of words and counts, so the Main is able to ask how many times a particular word appears in the web page.
