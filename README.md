# mot-uiaw-feb21-challenge-2
Ministry of Testing automation week February 2021, Challenge 2 - Clean up messy code

The challenge advised to look into using page object models, looking in to waits as well as some NUnit features to make things easier.

Despite the final solution reflecting this I didn't want to jump ahead and potentially over engineer anything and so took an incrumental approach and
only introduced things when it felt necessary.

## Approach
The approach for completing this challenge was to follow a TDD approach:
`Red, green, refactor` and as soon as any progress was made these changes were commited to Github.

Approach:

* Run tests and confirm tests passing
* Make small refactor
* Run tests, these would fail
* Fix test
* Run all tests and confirm they are passing
* Commit changes to Github


### Initial refactor
Each test was refactored seperately and the above approach carried out to test changes.

Some of the things that were initially done were:

* Use better selectors i.e. Id over xpath
* Remove sleeps where possible and where couldn't reduce them to improve feedback from tests
* Refactor and removal of code which wasn't required
* Introduce setup and teardown for tests to avoid duplication of driver initialise and quit

### Page objects / removal of thread sleeps
The following things were done to approach using page objects to help make the tests easier to maintain.

Initially the concept of a base page was introduced to handle all driver initialisation and quit. Here things common between tests were placed.

Next, all thread sleeps were removed and within the initialise of the driver I introduced an implicit wait for 10 seconds, this ensured the driver would wait for up
to 10 seconds before throwing an exception when trying to find an element within one of the tests.

The tests were still looking not great, lots of interactions with elements for example sat within the tests. For each test I introduced a page object where necessary
where lots of the interactions with elements could be moved to, this made the readability of the tests a lot better as well as improve maintaining and updating the tests later on.

Finally, some of the tests were doing asserts which were not great, where possible these were improved. I introduced dynamic data also to help ensure the page could accept different values and
also asserted this data existed rather than just check row counts. The test for checking a bold style I added a `TODO:` comment. Whilst I could check the css property had the correct style this
would be much better as a visual assertion but that was beyond the scope for this challenge.


### What else might I do if I had more time?
Some of the below were out of scope for this challenge. If I had more time and or if the challenge allowed I might have:
* Looked at whether some of the tests actually add value and if not remove them
* Looked at some other tests which might add value and add them
* Checked if some of the existing tests could be refactored to further improve readability, this is always easier when someone else is trying to read and understand your code via reviews or pairing etc
* Looked at visual testing and see if this could have helped in any way, the checking unread emails were bold is certainly something viual testing is there for
* Address the remaining todos in the test suite