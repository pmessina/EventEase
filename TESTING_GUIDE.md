# EventEase Testing Guide

## Test Scenarios

### ✅ Test 1: Home Page Navigation

**Steps:**
1. Launch the application (F5)
2. Verify the home page loads at `/`
3. Check that the hero section displays "Welcome to EventEase"
4. Verify the 4 feature cards are visible
5. Click "Browse Events" button in hero section
6. Verify navigation to `/events`

**Expected Results:**
- Home page displays correctly
- All sections are visible and styled properly
- Navigation works smoothly
- URL changes to `/events`

---

### ✅ Test 2: Events List and Search

**Steps:**
1. Navigate to `/events` (or click Browse Events)
2. Verify all 6 events are displayed
3. Note the event count: "Showing 6 of 6 events"
4. Type "Tech" in the search box
5. Verify only "Tech Innovation Summit 2025" is shown
6. Type "Chicago" in the search box
7. Verify only "Business Leadership Workshop" is shown
8. Clear the search box
9. Verify all 6 events are displayed again

**Expected Results:**
- Events load correctly
- Search filters work in real-time
- Event count updates dynamically
- All events return when search is cleared

---

### ✅ Test 3: Event Card Component Display

**Steps:**
1. Go to `/events`
2. Find the "Summer Music Festival" event card
3. Verify the following information is displayed:
   - Event Name: "Summer Music Festival"
   - Category badge: "Entertainment"
   - Date: "Jun 10, 2025 - 12:00 PM"
   - Location: "Central Park, Austin"
   - Description text
   - Capacity: 2000
   - Price: $75.00
   - Two buttons: "View Details" and "Register"

**Expected Results:**
- All event data displays correctly
- Data binding works properly
- Buttons are clickable and styled
- Card has hover effect

---

### ✅ Test 4: Event Details Page

**Steps:**
1. From events list, click "View Details" on any event
2. Verify URL changes to `/events/{id}` (e.g., `/events/1`)
3. Check the page displays:
   - Event name in header
   - Category badge
   - Date & Time
   - Location
   - Capacity
   - Price
   - Full description
4. Click "Register Now" button
5. Verify navigation to registration page

**Expected Results:**
- Details page loads with correct data
- Route parameter works correctly
- All information displays properly
- Navigation buttons work

---

### ✅ Test 5: Invalid Event ID Handling

**Steps:**
1. Manually navigate to `/events/999` (invalid ID)
2. Verify the "Event Not Found" message displays
3. Check that the error icon is visible
4. Click "Browse All Events" button
5. Verify return to events list

**Expected Results:**
- Error page displays correctly
- No crash or exception
- Recovery navigation works
- User-friendly error message

---

### ✅ Test 6: Registration Form Validation

**Steps:**
1. Navigate to any event details page
2. Click "Register Now"
3. Try to submit the empty form
4. Verify validation messages appear:
   - "First name is required"
   - "Last name is required"
   - "Email is required"
   - "Phone number is required"
5. Fill in only First Name: "John"
6. Try to submit
7. Verify other required fields still show errors

**Expected Results:**
- Form prevents submission when invalid
- Validation messages display correctly
- Required fields are enforced
- Optional fields don't show errors

---

### ✅ Test 7: Registration Form Submission

**Steps:**
1. Navigate to registration page for any event
2. Fill in all required fields:
   - First Name: "John"
   - Last Name: "Doe"
   - Email: "john.doe@example.com"
   - Phone Number: "(123) 456-7890"
3. Optionally fill Company: "Acme Corp"
4. Optionally fill Special Requirements: "Vegetarian meal"
5. Click "Complete Registration"
6. Wait for processing (loading spinner shows)
7. Verify success message displays:
   - Green check icon
   - "Registration Successful!"
   - Event details
   - Confirmation email note

**Expected Results:**
- Form accepts valid data
- Loading state shows during submission
- Success page displays correctly
- User information is preserved in success message

---

### ✅ Test 8: Email Validation

**Steps:**
1. Navigate to any registration page
2. Enter an invalid email: "notanemail"
3. Tab out of the field
4. Verify "Invalid email address" message appears
5. Correct the email: "test@example.com"
6. Verify validation message disappears

**Expected Results:**
- Email validation works correctly
- Invalid format is rejected
- Valid format is accepted
- Real-time validation feedback

---

### ✅ Test 9: Navigation Menu

**Steps:**
1. From any page, verify navigation menu shows:
   - Home
   - Browse Events
   - Counter (existing)
   - Weather (existing)
2. Click "Browse Events"
3. Verify navigation to `/events`
4. Click "Home"
5. Verify navigation to `/`
6. Verify active link is highlighted

**Expected Results:**
- All nav links are visible
- Navigation works from any page
- Active link has different styling
- Menu works on mobile (toggle button)

---

### ✅ Test 10: Back Navigation

**Steps:**
1. Go to home page
2. Navigate to events list
3. Click "View Details" on an event
4. Click "Back to Events" link
5. Verify return to events list
6. Click "View Details" again
7. Click "Register Now"
8. Click "Back to Event Details"
9. Verify return to details page

**Expected Results:**
- All back links work correctly
- Navigation maintains context
- No loss of data when navigating back

---

### ✅ Test 11: Responsive Design

**Steps:**
1. Open the application in browser
2. Open browser DevTools (F12)
3. Toggle device toolbar (Ctrl+Shift+M)
4. Test these screen sizes:
   - Mobile (375px width)
   - Tablet (768px width)
   - Desktop (1200px width)
5. Navigate through all pages at each size

**Expected Results:**
- Layout adapts to different screen sizes
- No horizontal scrolling
- Text remains readable
- Buttons are appropriately sized
- Navigation menu works on mobile

---

### ✅ Test 12: Event Card Actions

**Steps:**
1. Go to events list
2. On the first event card, click "Register"
3. Verify navigation to registration page
4. Go back to events list
5. On the same event, click "View Details"
6. Verify navigation to details page
7. From details page, click "Register Now"
8. Verify navigation to registration page

**Expected Results:**
- Both registration paths work
- Event ID is correctly passed in URL
- Correct event data loads on each page

---

### ✅ Test 13: Search Performance

**Steps:**
1. Go to events list
2. Rapidly type in search box: "TechBusiness"
3. Backspace to clear
4. Type "Free" (should show Product Launch Event)
5. Clear and type "New York"
6. Verify results update smoothly

**Expected Results:**
- Search is responsive
- No lag or freezing
- Results update as you type
- No errors in browser console

---

### ✅ Test 14: Multiple Event Registration Flow

**Steps:**
1. Register for "Tech Innovation Summit 2025"
2. After success, click "Browse More Events"
3. Find "Summer Music Festival"
4. Click "Register" directly from card
5. Fill out form with different information
6. Submit and verify success

**Expected Results:**
- Can register for multiple events
- Each registration is independent
- Navigation works smoothly between registrations

---

### ✅ Test 15: Direct URL Navigation

**Steps:**
1. Manually enter these URLs in the browser:
   - `http://localhost:5264/`
   - `http://localhost:5264/events`
   - `http://localhost:5264/events/3`
   - `http://localhost:5264/events/3/register`
2. Verify each page loads correctly

**Expected Results:**
- Direct URL navigation works
- Route parameters are parsed correctly
- Each page displays appropriate content
- No 404 errors for valid routes

---

## Data Binding Verification Checklist

### Event Card Component
- [ ] Event name displays correctly
- [ ] Date formats properly
- [ ] Location shows accurately
- [ ] Description text appears
- [ ] Category badge matches event type
- [ ] Price displays with $ symbol (or FREE)
- [ ] Capacity number shows correctly

### Registration Form
- [ ] Two-way binding works for all inputs
- [ ] Input values persist while typing
- [ ] Form data is available in @code block
- [ ] Success page shows submitted values

### Search Functionality
- [ ] Search term binds to input field
- [ ] Filtered results reflect search term
- [ ] Event count updates with filters

---

## Browser Testing

Test in multiple browsers:
- [ ] Microsoft Edge
- [ ] Google Chrome
- [ ] Mozilla Firefox
- [ ] Safari (if available)

---

## Performance Checklist

- [ ] Pages load quickly (< 2 seconds)
- [ ] No console errors
- [ ] Smooth animations
- [ ] No memory leaks (check DevTools Performance tab)
- [ ] Forms submit without delay

---

## Debugging Exercise Ideas

1. **Set breakpoint** in `Events.razor` > `HandleSearch()` method
2. **Set breakpoint** in `EventDetails.razor` > `OnInitializedAsync()`
3. **Set breakpoint** in `EventRegistration.razor` > `HandleRegistration()`
4. **Watch variable**: `registration.Email` in registration form
5. **Inspect**: `eventItem` object in event details page

---

## Common Issues to Check

❌ **If events don't display:**
- Check EventService is registered in Program.cs
- Verify GetAllEventsAsync() is called in OnInitializedAsync()

❌ **If navigation doesn't work:**
- Check @page directive is at the top of components
- Verify route parameters match (e.g., {id:int})

❌ **If validation doesn't work:**
- Ensure DataAnnotationsValidator is in EditForm
- Check [Required] attributes are on model properties
- Verify ValidationMessage components are added

❌ **If styling looks wrong:**
- Check .css files are named correctly (match .razor file)
- Verify CSS isolation is working
- Clear browser cache

---

## Success Criteria

✅ All pages load without errors
✅ Navigation works between all pages
✅ Event data displays correctly
✅ Search filters events properly
✅ Form validation works
✅ Registration completes successfully
✅ Responsive on mobile and desktop
✅ No console errors
✅ Back navigation works
✅ Route parameters function correctly

---

**Congratulations!** If all tests pass, your EventEase application is fully functional and ready for Activity 2 debugging exercises! 🎉
